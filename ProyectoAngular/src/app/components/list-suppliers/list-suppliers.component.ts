import { Component, OnInit, ViewChild} from '@angular/core';
import { Supplier } from 'src/app/core/models/model-supplier';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { SuppliersService } from '../service/suppliers.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { DialogBoxComponent } from '../dialog-box/dialog-box.component';

@Component({
  selector: 'app-list-suppliers',
  templateUrl: './list-suppliers.component.html',
  styleUrls: ['./list-suppliers.component.css']
})
export class ListSuppliersComponent implements OnInit{

  suppliers : Supplier[] = []

  displayedColumns: string[] = ["SupplierID", "CompanyName", "ContactName", "ContactTitle",'accionDelete'];
  
  dataSource = new MatTableDataSource<Supplier>(this.suppliers);

  @ViewChild(MatPaginator) paginator! : MatPaginator;
  @ViewChild(MatSort) sort! : MatSort;

  constructor( private suppliersService : SuppliersService,
    private _snackBar: MatSnackBar, private dialog: MatDialog, ){ 

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

