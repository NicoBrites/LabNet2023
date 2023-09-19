import { Component, OnInit, Output, ViewChild} from '@angular/core';
import { Supplier } from 'src/app/core/models/model-supplier';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { SuppliersService } from '../service/suppliers.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { DialogBoxComponent } from '../dialog-box/dialog-box.component';
import { AdministratorSuppliersComponent } from '../administrator-suppliers/administrator-suppliers.component';
import { SupplierUpdate } from 'src/app/core/models/mode-supplier-update';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-list-suppliers',
  templateUrl: './list-suppliers.component.html',
  styleUrls: ['./list-suppliers.component.css']
})
export class ListSuppliersComponent implements OnInit{


  public supplierEnviado! : SupplierUpdate

  suppliers : Supplier[] = []

  displayedColumns: string[] = ["SupplierID", "CompanyName", "ContactName", "ContactTitle",'accionEdit','accionDelete'];
  
  dataSource = new MatTableDataSource<Supplier>(this.suppliers);

  @ViewChild(MatPaginator) paginator! : MatPaginator;
  @ViewChild(MatSort) sort! : MatSort;

  constructor( private suppliersService : SuppliersService,
    private _snackBar: MatSnackBar, private dialog: MatDialog, 
    private route : ActivatedRoute ){   
     
  }

  ngOnInit(): void{
    this.getAllSuppliers();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action);
  }
  refresh(){
    window.location.reload();
  }

  deleteSupplier(supplierId:number){
    const dialogRef = this.dialog.open(DialogBoxComponent, {})

    dialogRef.afterClosed().subscribe(res => {
      if (res){
        this.suppliersService.deleteSupplier(supplierId).subscribe({

          complete: ()=>{
            this.openSnackBar('Supplier eliminado!', 'Okey')
            setTimeout(this.refresh, 3000);
    
          },
          error: (err)=>{
            alert(err.error.Message);
          }
        })
      }
    })
  }

  editSupplier(supplier:Supplier){
    var CompanyName = supplier.CompanyName;
    var ContactName = supplier.ContactName;
    var ContactTitle = supplier.ContactTitle;
    this.supplierEnviado = {CompanyName ,ContactName, ContactTitle }
    const dialogRef = this.dialog.open(AdministratorSuppliersComponent, {data : this.supplierEnviado })
    dialogRef.afterClosed().subscribe(res => {
    console.log(res)
    if (res != false && res != null)
      {
        this.suppliersService.updateSupplier(supplier.SupplierID, res).subscribe({
          complete: ()=>{
            this.openSnackBar('Supplier updateado!', 'Okey')
            setTimeout(this.refresh, 3000);
          },
          error: (err)=>{
            alert(err.error.message);
            }
          })
      }
    })    
  }

  createNewSupplier(){
    var CompanyName = "ESTOYVALIDANDOQUENOESUNEDIT-";
    var ContactName = "";
    var ContactTitle = "";
    this.supplierEnviado = {CompanyName ,ContactName, ContactTitle }
    const dialogRef = this.dialog.open(AdministratorSuppliersComponent, {data : this.supplierEnviado})
    dialogRef.afterClosed().subscribe(res => {
    console.log(res)
    if (res != false && res != null)
      {
        this.suppliersService.postSupplier(res).subscribe({
          complete: ()=>{
            this.openSnackBar('Supplier creado!', 'Okey')
            setTimeout(this.refresh, 3000);

          },
        error: (err)=>{
          alert(err.error.message);
        }
        })
      }  
    })
  }

  getAllSuppliers(){
    this.suppliersService.getAllSuppliers().subscribe(
      {
        next:(result)=>{
          this.dataSource.data = result;         
        },    
        error:(err)=>{
          alert(err.error.Message);
        }
      }
    )
  } 
}

