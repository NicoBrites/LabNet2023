import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './components/shared/shared.module';
import { ListSuppliersComponent } from './components/list-suppliers/list-suppliers.component';
import { AdministratorSuppliersComponent } from './components/administrator-suppliers/administrator-suppliers.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ListShippersComponent } from './components/list-shippers/list-shippers.component';
import { AdministratorShippersComponent } from './components/administrator-shippers/administrator-shippers.component';


@NgModule({
  declarations: [
    AppComponent,
    ListSuppliersComponent,
    AdministratorSuppliersComponent,
    NavbarComponent,
    ListShippersComponent,
    AdministratorShippersComponent,

  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    SharedModule,
    HttpClientModule,    
    ReactiveFormsModule,

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
