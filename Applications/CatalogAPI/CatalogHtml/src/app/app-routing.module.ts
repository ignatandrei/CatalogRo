import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser'
import { FormatsComponent } from './formats/formats.component';
import { CategoriesComponent } from './categories/categories.component';
import { MatMenuModule, MatCardModule, MatToolbarModule, MatInputModule, MatButtonModule, MatSelectModule, MatIconModule } from '@angular/material';
import { AdminComponent} from './admin/admin.component';
const routes: Routes = [
  { path: '', redirectTo: '/admin', pathMatch: 'full' },
  {

    path: 'admin',
    
    data: {
      breadcrumb: 'admin'
    },
    children: [
      {
        path: '',
        component: AdminComponent,
        data: {
          breadcrumb: 'Links'
        }
      },
      {
        path: 'formats',
        component: FormatsComponent,
        data: {
          breadcrumb: 'formats'
        }
      },
      {
        path: 'categories', component: CategoriesComponent, data: {
          breadcrumb: 'categories'
        },}
    ]
  }
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
