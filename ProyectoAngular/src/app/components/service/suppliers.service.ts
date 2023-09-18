import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Environment } from 'src/app/environments/environment';
import { Observable } from 'rxjs'
import { Supplier } from 'src/app/core/models/model-supplier';
import { SupplierUpdate } from 'src/app/core/models/mode-supplier-update';

@Injectable({
  providedIn: 'root',
})
export class SuppliersService {

  apiUrl: string = Environment.apiLab;
  constructor(private http: HttpClient) {}

  public getAllSuppliers(): Observable<Array<Supplier>>{
    let url =  `${this.apiUrl}Suppliers`;
    return this.http.get<Array<Supplier>>(url);
  }

  public postSupplier(supplierRequest: Supplier): Observable<any>{
    let url =  `${this.apiUrl}Suppliers`;
    return this.http.post(url, supplierRequest);
  }

  public deleteSupplier(id: number)
  {
    let url =  `${this.apiUrl}Suppliers/`;
    return this.http.delete(url + id); 
  }

  public updateSupplier(id : number,request: SupplierUpdate )
  {
      return this.http.put(Environment.apiLab + "Suppliers/" +id,request);
  }
}
