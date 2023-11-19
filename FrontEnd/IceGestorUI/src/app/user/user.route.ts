import { Component, NgModule } from '@angular/core';
import { UserAppComponent } from './user.app.component';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
const userRouterConfig: Routes = [
    {
        path: '', component: UserAppComponent,
        children: [
            { path: 'login', component: LoginComponent }
        ]
    }
]

@NgModule({
    imports: [
        RouterModule.forChild(userRouterConfig)
    ],
    exports: []
})
export class UserRoutingModule { }