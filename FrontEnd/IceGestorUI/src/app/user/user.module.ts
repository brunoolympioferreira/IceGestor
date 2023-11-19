import { NgModule } from "@angular/core";
import { UserAppComponent } from "./user.app.component";
import { RouterModule } from "@angular/router";
import { LoginComponent } from "./login/login.component";
import { CommonModule } from "@angular/common";

@NgModule({
    declarations: [
        UserAppComponent,
        LoginComponent
    ],
    imports: [
        CommonModule,
        RouterModule
    ],
    exports: [
        LoginComponent,
    ],
    providers: []
})
export class UserModule { }