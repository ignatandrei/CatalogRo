import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from "@angular/forms";

import { AppComponent } from './app.component';
import { FormatsComponent } from './formats/formats.component';
import { FormatComponent } from './format/format.component';
import { FormatService } from './format.service';
import { CategoryComponent } from './category/category.component';
import { CategoriesComponent } from './categories/categories.component';
import { CategoryService } from './category.service';

import { AppRoutingModule } from './/app-routing.module';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations"
import {MatMenuModule,MatCardModule, MatToolbarModule, MatInputModule, MatButtonModule, MatSelectModule, MatIconModule } from '@angular/material';

@NgModule({
  declarations: [
    AppComponent,
    FormatsComponent,
    FormatComponent,
    CategoryComponent,
    CategoriesComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,    
    HttpClientModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatIconModule,
    MatMenuModule,
    MatCardModule
  ],
  providers: [
    FormatService,
    CategoryService,
    AppRoutingModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
