import { NgModule } from '@angular/core';
import { HomeComponent } from "./home/home.component";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";

@NgModule({
    declarations: [
        HomeComponent
    ],
    imports: [
        CommonModule,
        RouterModule
    ],
    exports: []
})
export class NavegacaoModule { }