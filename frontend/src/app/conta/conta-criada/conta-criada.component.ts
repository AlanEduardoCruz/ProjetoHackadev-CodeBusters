import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { CriarContaService } from '../../servicos/criarconta.service';
import { AuthService } from '../../auth.service';
import { MudarConta } from '../../modelos/MudarConta';
import { MudarContaService } from '../../servicos/mudar-conta.service';
import { ContaInfoService } from '../../servicos/getcontainfo.service';
import { NgxCurrencyDirective, NgxCurrencyInputMode } from 'ngx-currency';
import { NgxMaskDirective } from 'ngx-mask';

@Component({
  selector: 'app-conta-criada',
  standalone: true,
  imports: [RouterModule, ReactiveFormsModule, NgxCurrencyDirective, NgxMaskDirective],
  templateUrl: './conta-criada.component.html',
  styleUrl: './conta-criada.component.css'
})
export class ContaCriadaComponent {
  changeAccountForm!: FormGroup

  ngOnInit() {
    this.changeAccountForm = new FormGroup({
      'pix-geral': new FormControl(null, 
        [
        Validators.required,
        Validators.minLength(4),
        ]),
      'pix-noturno': new FormControl(null, 
        [
        Validators.required 
        ]),
      'pin': new FormControl(null, 
        [
        Validators.required 
        ]),
    })



  }

  constructor(private contaService:MudarContaService, private authService: AuthService, private route: Router, private contaInfoService: ContaInfoService) {}

  onSubmit(): void {
    console.log(this.changeAccountForm)
    this.changeAccountForm?.markAllAsTouched();
    if (this.changeAccountForm?.valid) {
      let mudarContaData: MudarConta = {
        // pin: this.changeAccountForm.get('pin')?.value || '',
        // limites: {
        limitePixGeral: this.changeAccountForm.get('pix-geral')?.value,
        limitePixNoturno: this.changeAccountForm.get('pix-noturno')?.value,
        pin: this.changeAccountForm.get('pin')?.value
      }
      
      this.contaService.alterarConta(mudarContaData)
        .subscribe({
          next: (retorno: any) => {
            console.log(retorno)
            this.changeAccountForm.reset();
            // setTimeout(() => {
            //   this.route.navigate(['/home']);
            // }, 1200);
          },
          error: (error) => {
            console.log(error);
          }
        });
    }
  }
}
