import { NgModule } from '@angular/core';
import { HomeComponent } from "./home/home.component";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { MenuComponent } from './menu/menu.component';
import { FooterComponent } from './footer/footer.component';

@NgModule({
    declarations: [
        HomeComponent,
        MenuComponent,
        FooterComponent
    ],
    imports: [
        CommonModule,
        RouterModule
    ],
    exports: [
        MenuComponent,
        FooterComponent,
        HomeComponent
    ]
})
export class NavegacaoModule { }