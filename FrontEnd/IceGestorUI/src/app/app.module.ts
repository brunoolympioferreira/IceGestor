import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavegacaoModule } from './navegacao/navegacao.module';
import { ToastrModule } from 'ngx-toastr';
import { NarikCustomValidatorsModule } from '@narik/custom-validators';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NavegacaoModule,
    ToastrModule.forRoot(),
    NarikCustomValidatorsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
