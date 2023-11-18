import { NgModule } from '@angular/core';
import { HomeComponent } from "./home/home.component";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { MenuComponent } from './menu/menu.component';

@NgModule({
    declarations: [
        HomeComponent,
        MenuComponent
    ],
    imports: [
        CommonModule,
        RouterModule
    ],
    exports: [
        MenuComponent
    ]
})
export class NavegacaoModule { }