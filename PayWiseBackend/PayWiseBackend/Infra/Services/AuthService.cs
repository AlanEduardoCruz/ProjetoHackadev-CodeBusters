﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PayWiseBackend.Domain.Context;
using PayWiseBackend.Domain.DTOs;
using PayWiseBackend.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PayWiseBackend.Infra.Services;

public class AuthService : IAuthService
{
    private readonly PaywiseDbContext _context;
    private readonly IConfiguration _config;

    public AuthService(PaywiseDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    public string GenerateAccessToken(int clienteId)
    {
        string accessToken = GenerateToken(clienteId, TokenType.Access);
        return accessToken;
    }

    public string GenerateRefreshToken(int clienteId)
    {
        string refreshToken = GenerateToken(clienteId, TokenType.Refresh);
        return refreshToken;
    }

    public string GenerateToken(int clienteId, TokenType type)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_config["Jwt:key"]);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, clienteId.ToString())
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = type == TokenType.Refresh ? DateTime.UtcNow.AddDays(7) : DateTime.UtcNow.AddMinutes(10),
            Issuer = _config["Jwt:issuer"],
            Audience = _config["Jwt:audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public int? GetClienteIdFromAccessToken(string accessToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_config["Jwt:key"]);

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _config["Jwt:issuer"],
            ValidAudience = _config["Jwt:audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };

        try
        {
            ClaimsPrincipal principal = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out SecurityToken validatedToken);

            Claim clienteId = principal.FindFirst(ClaimTypes.NameIdentifier);
            if (clienteId is null)
                return null;

            var clienteIdValue = Convert.ToInt32(clienteId.Value);

            return clienteIdValue;
        }
        catch (Exception err)
        {
            return null;
        }
    }

    public string HashPassword(string senha)
    {
        var senhaHash = BCrypt.Net.BCrypt.HashPassword(senha);
        return senhaHash;
    }

    public async Task SalvarSessao(int clienteId, string refreshToken)
    {
        var sessaoParaAtualizar = await _context.Sessoes.FirstOrDefaultAsync(s => s.ClienteId == clienteId);
        if (sessaoParaAtualizar is null)
        {
            Sessao sessao = new Sessao()
            {
                RefreshToken = refreshToken,
                ClienteId = clienteId,
            };
            await _context.Sessoes.AddAsync(sessao);
        }

        sessaoParaAtualizar!.RefreshToken = refreshToken;
        _context.Sessoes.Update(sessaoParaAtualizar);

        await _context.SaveChangesAsync();
    }

    public async Task<Cliente?> ValidateCredentials(CreateLoginDTO loginCredentials)
    {
        var cliente = await _context.Clientes.SingleOrDefaultAsync(cliente => cliente.Cpf == loginCredentials.Cpf);

        if (cliente is null)
        {
            return null;
        }

        bool password = BCrypt.Net.BCrypt.Verify(loginCredentials.Senha, cliente.Senha);

        if (!password)
        {
            return null;
        }

        return cliente;
    }


}
