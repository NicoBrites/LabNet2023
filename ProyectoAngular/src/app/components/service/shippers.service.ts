import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Environment } from 'src/app/environments/environment';
import { Observable } from 'rxjs'
import { Shipper } from 'src/app/core/models/model-shipper';
import { ShipperUpdate } from 'src/app/core/models/model-shipper-update';

@Injectable({
  providedIn: 'root'
})
export class ShippersService {

  apiUrl: string = Environment.apiLab;
  constructor(private http: HttpClient) {}

  public getAllShippers(): Observable<Array<Shipper>>{
    let url =  `${this.apiUrl}Shippers`;
    return this.http.get<Array<Shipper>>(url);
  }

  public postShipper(shipperRequest: Shipper): Observable<any>{
    let url =  `${this.apiUrl}Shippers`;
    return this.http.post(url, shipperRequest);
  }

  public deleteShipper(id: number)
  {
    let url =  `${this.apiUrl}Shippers/`;
    return this.http.delete(url + id); 
  }

  public updateShipper(id : number,request: ShipperUpdate )
  {
      return this.http.put(Environment.apiLab + "Shippers/" +id,request);
  }
}
