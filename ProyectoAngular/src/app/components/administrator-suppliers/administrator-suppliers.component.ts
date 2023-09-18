import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Supplier } from 'src/app/core/models/model-supplier';
import { SuppliersService } from '../service/suppliers.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SupplierUpdate } from 'src/app/core/models/mode-supplier-update';


@Component({
  selector: 'app-administrator-suppliers',
  templateUrl: './administrator-suppliers.component.html',
  styleUrls: ['./administrator-suppliers.component.css']
})
export class AdministratorSuppliersComponent implements OnInit {

    form!: FormGroup;
    supplier!: Supplier;
    supplierUpdate!: SupplierUpdate;

    constructor(private readonly fb: FormBuilder,  private service: SuppliersService, private _snackBar: MatSnackBar) { }

     //Getters

    get supplierIDGet(): AbstractControl{
      return this.form.get('supplierID')!;
    }
    
    get companyNameGet(): AbstractControl{
      return this.form.get('companyName')!;
    }

    get contactNameGet(): AbstractControl{
      return this.form.get('contactName')!;
    }

    get contactTitleGet(): AbstractControl{
      return this.form.get('contactTitle')!;
    }

    noCaracteresEspeciales(control: AbstractControl): Validators | null {
      const caracteresEspeciales = /[!@#$%^&*()_+{}\[\]:;<>,.?~\\/-]/;
    
      if (caracteresEspeciales.test(control.value)) {
        return { caracteresEspeciales: true };
      }
    
      return null;
    }

    ngOnInit(): void {
      this.form = this.fb.group({
        supplierID: ['', [Validators.pattern('^[0-9]*$'), Validators.maxLength(10)]],
        companyName: [''.trim(), [Validators.required, Validators.maxLength(40), this.noCaracteresEspeciales]],
        contactName: [''.trim(), [Validators.maxLength(30), this.noCaracteresEspeciales]],
        contactTitle: [''.trim(), [Validators.maxLength(30), this.noCaracteresEspeciales]]
        
      });
    }

    openSnackBar(message: string, action: string) {
      this._snackBar.open(message, action);
    }
    refresh(){
      window.location.reload();
    }

    onCreate(): void {
      var SupplierID = this.supplierIDGet.value;
      var CompanyName = this.companyNameGet.value;
      var ContactName = this.contactNameGet.value;
      var ContactTitle= this.contactTitleGet.value;
      this.supplier = {SupplierID, CompanyName, ContactName, ContactTitle}
      this.service.postSupplier(this.supplier).subscribe(
        {
          complete: ()=>{
            this.openSnackBar('Supplier creado!', 'Okey')
            setTimeout(this.refresh, 3000);
 
          },
          error: (err)=>{
            alert(err.error.Message);
          }
        }
      );
    }

    onUpdate(): void{
      var SupplierID = this.supplierIDGet.value;
      if(SupplierID == "")
      {
        this.openSnackBar('Error! No podes Updatear con el ID Vacio.', 'Okey')
      }
      else{
        var CompanyName = this.companyNameGet.value;
        var ContactName = this.contactNameGet.value;
        var ContactTitle= this.contactTitleGet.value;
        this.supplierUpdate = {CompanyName, ContactName, ContactTitle}
        this.service.updateSupplier(SupplierID, this.supplierUpdate).subscribe(
          {
            complete: ()=>{
              this.openSnackBar('Supplier updateado!', 'Okey')
              setTimeout(this.refresh, 3000);
  
            },
            error: (err) => {
              console.log("🚀 ~ file: administrator-suppliers.component.ts:107 ~ AdministratorSuppliersComponent ~ onUpdate ~ err:", err)
              alert(err.error.Message);
            }
          }
        );
      }
    
    }
    onClickLimpiar(): void {
      const supplierCtrl = this.form.get('supplierID');
      const companyNameCtrl = this.form.get('companyName');
      const contactNameCtrl = this.form.get('contactName');
      const contactTitleCtrl = this.form.get('contactTitle');
      if (supplierCtrl){
        supplierCtrl.setValue('')
      }
      if (companyNameCtrl){
        companyNameCtrl.setValue('')
      }
      if (contactNameCtrl){
        contactNameCtrl.setValue('')
      }
      if (contactTitleCtrl){
        contactTitleCtrl.setValue('')
      }
    } 
    
}
