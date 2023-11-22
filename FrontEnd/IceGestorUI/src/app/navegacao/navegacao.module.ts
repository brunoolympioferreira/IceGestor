import { User } from '../user/models/user';
import { NgModule } from '@angular/core';
import { HomeComponent } from "./home/home.component";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { MenuComponent } from './menu/menu.component';
import { FooterComponent } from './footer/footer.component';
import { UserAppComponent } from '../user/user.app.component';
import { LoginComponent } from '../user/login/login.component';
import { UserModule } from '../user/user.module';

@NgModule({
    declarations: [
        HomeComponent,
        MenuComponent,
        FooterComponent
    ],
    imports: [
        CommonModule,
        RouterModule,
        UserModule
    ],
    exports: [
        MenuComponent,
        FooterComponent,
        HomeComponent,
    ]
})
export class NavegacaoModule { }