import { Component, OnInit, Inject, Input } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SupplierUpdate } from 'src/app/core/models/mode-supplier-update';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { SupplierSend } from 'src/app/core/models/model-supplier-send';



@Component({
  selector: 'app-administrator-suppliers',
  templateUrl: './administrator-suppliers.component.html',
  styleUrls: ['./administrator-suppliers.component.css']
})
export class AdministratorSuppliersComponent implements OnInit {

  supplierUpdate! : SupplierUpdate;
  form!: FormGroup;

  constructor(private readonly fb: FormBuilder, private _snackBar: MatSnackBar,
     public dialogRef: MatDialogRef<AdministratorSuppliersComponent>,
    @Inject(MAT_DIALOG_DATA) public supplierSend: SupplierSend ) {}

  //Getters
  
  get companyNameGet(): AbstractControl{
    return this.form.get('companyName')!;
  }

  get contactNameGet(): AbstractControl{
    return this.form.get('contactName')!;
  }

  get contactTitleGet(): AbstractControl{
    return this.form.get('contactTitle')!;
  }

  noEspacioEnBlanco(control: AbstractControl):  Validators | null{
    if (control.value && control.value.trim() === '') {
      return { 'espacioEnBlanco': true };
    }
    return null;
  }

  noCaracteresEspeciales(control: AbstractControl): Validators | null {
    const caracteresEspeciales = /[!@#$%^&*'()_+{}\[\]:;<>,.?~\\/-]/;
  
    if (caracteresEspeciales.test(control.value)) {
      return { caracteresEspeciales: true };
    }
  
    return null;
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      companyName: [''.trim(), [Validators.required, Validators.maxLength(40), this.noEspacioEnBlanco]],
      contactName: [''.trim(), [Validators.maxLength(30)]],
      contactTitle: [''.trim(), [Validators.maxLength(30)]]
    });
    if (this.supplierSend.edit == true)
    {
      this.form.setValue({
        companyName: this.supplierSend.CompanyName,
        contactName: this.supplierSend.ContactName,
        contactTitle: this.supplierSend.ContactTitle
      });
    }

  }
  
  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action);
  }
  refresh(){
    window.location.reload();
  }

  onUpdate(): SupplierUpdate{
    var CompanyName = this.companyNameGet.value;
    var ContactName = this.contactNameGet.value;
    var ContactTitle= this.contactTitleGet.value;
    this.supplierUpdate = {CompanyName, ContactName, ContactTitle}
    return this.supplierUpdate
  }

  enviarFormulario() {
    const formData = this.onUpdate();
    if (formData.CompanyName.trim() == "")
    {
      this.dialogRef.close(false);   
    }
    this.dialogRef.close(formData);
  }

  volverList() {
    this.dialogRef.close(false);
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
