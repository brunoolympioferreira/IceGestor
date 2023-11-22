import { NgModule } from "@angular/core";
import { UserAppComponent } from "./user.app.component";
import { RouterModule } from "@angular/router";
import { LoginComponent } from "./login/login.component";
import { CommonModule } from "@angular/common";
import { CreateUserComponent } from './create-user/create-user.component';
import { UserRoutingModule } from "./user.route";

@NgModule({
    declarations: [
        UserAppComponent,
        LoginComponent,
        CreateUserComponent
    ],
    imports: [
        CommonModule,
        RouterModule,
        UserRoutingModule
    ],
    exports: [
        LoginComponent,
        CreateUserComponent
    ],
    providers: []
})
export class UserModule { }