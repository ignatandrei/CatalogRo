import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser'
import { FormatsComponent } from './formats/formats.component';
import { MatMenuModule, MatCardModule, MatToolbarModule, MatInputModule, MatButtonModule, MatSelectModule, MatIconModule } from '@angular/material';

const routes: Routes = [
  { path: 'admin/formats', component: FormatsComponent }
];

@NgModule({
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule],
  declarations: []
})
export class AppRoutingModule { }
