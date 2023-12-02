import { NgModule } from "@angular/core";
import { UserAppComponent } from "./user.app.component";
import { RouterModule } from "@angular/router";
import { LoginComponent } from "./login/login.component";
import { CommonModule } from "@angular/common";
import { CreateUserComponent } from './create-user/create-user.component';
import { UserRoutingModule } from "./user.route";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { UserService } from "./services/user.service";
import { NarikCustomValidatorsModule } from "@narik/custom-validators";

@NgModule({
    declarations: [
        UserAppComponent,
        LoginComponent,
        CreateUserComponent
    ],
    imports: [
        CommonModule,
        RouterModule,
        UserRoutingModule,
        NarikCustomValidatorsModule,
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule,
    ],
    exports: [
        LoginComponent,
        CreateUserComponent
    ],
    providers: [UserService]
})
export class UserModule { }