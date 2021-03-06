import { NoCacheInterceptor } from './nocacheInterceptor';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule,ReactiveFormsModule } from "@angular/forms";


import { CdkTableModule } from '@angular/cdk/table';
import { AppComponent } from './app.component';
import { FormatsComponent } from './formats/formats.component';
import { FormatComponent } from './format/format.component';
import { FormatService } from './format.service';
import { ResursaDictsService } from './resursa.service';
import { CategoryComponent } from './category/category.component';
import { CategoriesComponent } from './categories/categories.component';
import { CategoryService } from './category.service';

import { AppRoutingModule } from './/app-routing.module';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations"
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import {
  MatAutocompleteModule,
  MatButtonModule,
  MatButtonToggleModule,
  MatCardModule,
  MatCheckboxModule,
  MatChipsModule,
  MatDatepickerModule,
  MatDialogModule,
  MatDividerModule,
  MatExpansionModule,
  MatGridListModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatMenuModule,
  MatNativeDateModule,
  MatPaginatorModule,
  MatProgressBarModule,
  MatProgressSpinnerModule,
  MatRadioModule,
  MatRippleModule,
  MatSelectModule,
  MatSidenavModule,
  MatSliderModule,
  MatSlideToggleModule,
  MatSnackBarModule,
  MatSortModule,
  MatStepperModule,
  MatTableModule,
  MatTabsModule,
  MatToolbarModule,
  MatTooltipModule,
} from '@angular/material';
import { BreadcrumbsComponent } from './breadcrumbs/breadcrumbs.component';
import { AdminComponent } from './admin/admin.component';
import { AdddataComponent } from './adddata/adddata.component';
import { ResursaComponent } from './resursa/resursa.component';
import { ResurseComponent } from './resurse/resurse.component';


@NgModule({
  declarations: [
    AppComponent,
    FormatsComponent,
    FormatComponent,
    CategoryComponent,
    CategoriesComponent,
    BreadcrumbsComponent,
    AdminComponent,
    AdddataComponent,
    ResursaComponent,    
    ResurseComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,    
    HttpClientModule,
    BrowserAnimationsModule,
    MatAutocompleteModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatStepperModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule
  ],
  providers: [
    FormatService,
    CategoryService,
    AppRoutingModule,
    ResursaDictsService,
    { provide: HTTP_INTERCEPTORS, useClass: NoCacheInterceptor, multi: true }

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
