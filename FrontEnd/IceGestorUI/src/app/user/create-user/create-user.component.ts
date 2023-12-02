import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControl, FormControlName, FormGroup, Validators } from '@angular/forms';
import { FormBaseComponent } from 'src/app/base-components/form-base-component';
import { User } from '../models/user';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CustomValidators } from '@narik/custom-validators';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html'
})
export class CreateUserComponent extends FormBaseComponent implements OnInit, AfterViewInit {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  errors: any[] = [];
  createForm: FormGroup;
  user: User

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private router: Router,
    private toastr: ToastrService) {
    super()

    this.validationMessages = {
      username: {
        required: 'Informe seu nome de usuário'
      },
      email: {
        required: 'Informe o e-mail',
        email: 'E-mail inválido'
      },
      password: {
        required: 'Informe a senha',
        rangeLength: 'A senha deve possuir entre 6 e 15 caracteres'
      }
    }

    super.configurarMensagensValidacaoBase(this.validationMessages);
  }

  ngOnInit(): void {
    let senha = new FormControl('', [Validators.required, CustomValidators.rangeLength([6, 15])])

    this.createForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: senha,
      username: ['', [Validators.required]]
    });
  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormularioBase(this.formInputElements, this.createForm)
  }

  criarConta() {
    if (this.createForm.dirty && this.createForm.valid) {
      this.user = Object.assign({}, this.user, this.createForm.value);
      this.userService.createUser(this.user)
        .subscribe({
          next: sucesso => { this.processarSucesso(sucesso) },
          error: falha => { this.processarFalha(falha) }
        })
      console.log(this.createForm.value);
    }
  }

  processarSucesso(response: any) {
    this.createForm.reset();
    this.errors = [];

    this.userService.LocalStorage.salvarDadosLocaisUsuario(response);

    let toast = this.toastr.success('Registro realizado com sucesso!', 'Bem vindo(a)!');

    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/home'])
      });
    }
  }

  processarFalha(fail: any) {
    this.errors = fail.errors;
    this.toastr.error('Nome de usuário e/ou email já existente, tente outro', 'Opa :(');
  }
}
