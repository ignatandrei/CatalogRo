import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormatsComponent } from './formats/formats.component';

const routes: Routes = [
  { path: 'admin/formats', component: FormatsComponent }
];

@NgModule({
  imports: [    
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule],
  declarations: []
})
export class AppRoutingModule { }
