import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
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
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [FormatService],
  bootstrap: [AppComponent]
})
export class AppModule { }
