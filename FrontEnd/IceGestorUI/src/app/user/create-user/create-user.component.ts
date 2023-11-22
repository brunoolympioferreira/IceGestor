import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControl, FormControlName, FormGroup, Validators } from '@angular/forms';
import { FormBaseComponent } from 'src/app/base-components/form-base-component';
import { User } from '../models/user';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CustomValidators } from '@narik/custom-validators';

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
    // private userService: UserService,
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
      username: ['', [Validators.required]],
      email: ['', [Validators.required], [Validators.email]],
      password: senha
    });
  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormularioBase(this.formInputElements, this.createForm)
  }

  criarConta() {

  }

  processarSucesso() {

  }

  processarFalha() {

  }
}
