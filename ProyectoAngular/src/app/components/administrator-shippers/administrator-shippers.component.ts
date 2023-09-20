import { Component, OnInit, Inject, Input } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ShipperUpdate } from 'src/app/core/models/model-shipper-update';
import { ShipperSend } from 'src/app/core/models/model-shipper-send';



@Component({
  selector: 'app-administrator-shippers',
  templateUrl: './administrator-shippers.component.html',
  styleUrls: ['./administrator-shippers.component.css']
})
export class AdministratorShippersComponent implements OnInit {

  shipperUpdate! : ShipperUpdate;
  form!: FormGroup;

  constructor(private readonly fb: FormBuilder, private _snackBar: MatSnackBar, 
    public dialogRef: MatDialogRef<AdministratorShippersComponent>,
    @Inject(MAT_DIALOG_DATA) public shipperSend: ShipperSend) { }

  //Getters

  get companyNameGet(): AbstractControl {
    return this.form.get('companyName')!;
  }

  get PhoneGet(): AbstractControl {
    return this.form.get('Phone')!;
  }

  noEspacioEnBlanco(control: AbstractControl): Validators | null {
    if (control.value && control.value.trim() === '') {
      return { 'espacioEnBlanco': true };
    }
    return null;
  }


  ngOnInit(): void {
    this.form = this.fb.group({
      companyName: [''.trim(), [Validators.required, Validators.maxLength(40), this.noEspacioEnBlanco]],
      Phone: [''.trim(), [Validators.maxLength(24)]],
    });
    if (this.shipperSend.edit == true) {
      this.form.setValue({
        companyName: this.shipperSend.CompanyName,
        Phone: this.shipperSend.Phone,
      });
    }

  }

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action);
  }
  refresh() {
    window.location.reload();
  }

  onUpdate(): ShipperUpdate {
    var CompanyName = this.companyNameGet.value;
    var Phone = this.PhoneGet.value;
    this.shipperUpdate = { CompanyName, Phone }
    return this.shipperUpdate
  }

  enviarFormulario() {
    const formData = this.onUpdate();
    if (formData.CompanyName.trim() == "") {
      this.dialogRef.close(false);
    }
    this.dialogRef.close(formData);
  }

  volverList() {
    this.dialogRef.close(false);
  }

  onClickLimpiar(): void {
    const shipperCtrl = this.form.get('shipperID');
    const companyNameCtrl = this.form.get('companyName');
    const PhoneCtrl = this.form.get('Phone');
    if (shipperCtrl) {
      shipperCtrl.setValue('')
    }
    if (companyNameCtrl) {
      companyNameCtrl.setValue('')
    }
    if (PhoneCtrl) {
      PhoneCtrl.setValue('')
    }
  }
}


