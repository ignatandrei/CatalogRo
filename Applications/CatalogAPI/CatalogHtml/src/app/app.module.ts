import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from "@angular/forms";

import { AppComponent } from './app.component';
import { FormatsComponent } from './formats/formats.component';
import { FormatComponent } from './format/format.component';
import { FormatService } from './format.service';

import { AppRoutingModule } from './/app-routing.module';
import { HttpClientModule, HttpClient } from '@angular/common/http';
@NgModule({
  declarations: [
    AppComponent,
    FormatsComponent,
    FormatComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,    
    HttpClientModule
  ],
  providers: [
    FormatService,
    AppRoutingModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
