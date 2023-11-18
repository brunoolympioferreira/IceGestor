import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LocalStorageUtils } from 'src/app/utils/local-storage';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html'
})
export class MenuComponent {
  token: string = ""
  username: string = "";
  localStorageUtils = new LocalStorageUtils();

  constructor(private router: Router) { }

  usuarioLogado(): boolean {
    this.token = this.localStorageUtils.obterTokenUsuario();
    this.username = this.localStorageUtils.obterNomeUsuario();

    return this.token !== null;
  }
}
