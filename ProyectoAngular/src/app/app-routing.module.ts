import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListSuppliersComponent } from './components/list-suppliers/list-suppliers.component';
import { AdministratorSuppliersComponent } from './components/administrator-suppliers/administrator-suppliers.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'home'},
  { path: 'suppliers', component: ListSuppliersComponent},
  { path: 'administrator', component: AdministratorSuppliersComponent},
  {
    path:'dashboard',
    loadChildren: () => import('./components/dashboard/dashboard.module').then((x)=>x.DashboardModule),
  },
  { path: '**', pathMatch: 'full', redirectTo: 'suppliers'},
];

@NgModule({
 imports: [RouterModule.forRoot(routes)],
 exports: [RouterModule],
})
export class AppRoutingModule { }
