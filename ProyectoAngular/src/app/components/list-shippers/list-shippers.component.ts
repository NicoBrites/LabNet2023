import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { ShippersService } from '../service/shippers.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { DialogBoxComponent } from '../dialog-box/dialog-box.component';
import { ShipperUpdate } from 'src/app/core/models/model-shipper-update';
import { Shipper } from 'src/app/core/models/model-shipper';
import { AdministratorShippersComponent } from '../administrator-shippers/administrator-shippers.component';

@Component({
  selector: 'app-list-shippers',
  templateUrl: './list-shippers.component.html',
  styleUrls: ['./list-shippers.component.css']
})
export class ListShippersComponent implements OnInit {

  public shipperEnviado!: ShipperUpdate

  shippers: Shipper[] = []

  displayedColumns: string[] = ["ShipperID", "CompanyName", "Phone", 'accionEdit', 'accionDelete'];

  dataSource = new MatTableDataSource<Shipper>(this.shippers);

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private shippersService: ShippersService,
    private _snackBar: MatSnackBar, private dialog: MatDialog) {

  }

  ngOnInit(): void {
    this.getAllShippers();
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
  refresh() {
    window.location.reload();
  }

  deleteShipper(shipperId: number) {
    const dialogRef = this.dialog.open(DialogBoxComponent, {})

    dialogRef.afterClosed().subscribe(res => {
      if (res) {
        this.shippersService.deleteShipper(shipperId).subscribe({
          complete: () => {
            this.openSnackBar('Shipper eliminado!', 'Okey')
            setTimeout(this.refresh, 2000);
          },
          error: (err) => {
            alert(err.error.Message);
          }
        })
      }
    })
  }

  editShipper(shipper: Shipper) {
    var CompanyName = shipper.CompanyName;
    var Phone = shipper.Phone;
    this.shipperEnviado = { CompanyName, Phone }
    const dialogRef = this.dialog.open(AdministratorShippersComponent, { data: this.shipperEnviado })
    dialogRef.afterClosed().subscribe(res => {
      console.log(res)
      if (res != false && res != null) {
        this.shippersService.updateShipper(shipper.ShipperID, res).subscribe({
          complete: () => {
            this.openSnackBar('Shipper updateado!', 'Okey')
            setTimeout(this.refresh, 2000);
          },
          error: (err) => {
            alert(err.error.message);
          }
        })
      }
    })
  }

  createNewShipper() {
    var CompanyName = "ESTOYVALIDANDOQUENOESUNEDIT-";
    var Phone = "";
    this.shipperEnviado = { CompanyName, Phone }
    const dialogRef = this.dialog.open(AdministratorShippersComponent, { data: this.shipperEnviado })
    dialogRef.afterClosed().subscribe(res => {
      if (res != false && res != null) {
        this.shippersService.postShipper(res).subscribe({
          complete: () => {
            this.openSnackBar('Shipper creado!', 'Okey')
            setTimeout(this.refresh, 2000);
          },
          error: (err) => {
            alert(err.error.message);
          }
        })
      }
    })
  }

  getAllShippers() {
    this.shippersService.getAllShippers().subscribe(
      {
        next: (result) => {
          this.dataSource.data = result;
        },
        error: (err) => {
          alert(err.error.Message);
        }
      }
    )
  }
}


