import { Component, Inject, ViewChild, AfterViewInit, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { jqxTreeGridComponent } from '../../../node_modules/jqwidgets-framework/jqwidgets-ts/angular_jqxtreegrid';

@Component({
  selector: 'brainware-orders',
  templateUrl: './brainware-orders.component.html'
})

export class OrdersComponent implements AfterViewInit {
  @ViewChild('treeGridReference') treeGrid: jqxTreeGridComponent;
  @Input() public companyId: number;

  public orderDetails: Sales.OrderDetails[];

  private baseUrl: string;

  private formatter: Intl.NumberFormat = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD',
    minimumFractionDigits: 2
  });

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngAfterViewInit(): void {

    this.treeGrid.createComponent(
      {
        height: 'auto',
        width: 'auto',
        showAggregates: false,
        showSubAggregates: true,
        filterable: true,
        columnsResize: true,
        columns: [
          { text: 'Name', minWidth: 100, width: 200 },
          {
            text: 'Product Name', dataField: 'productName', width: 150,
            cellsrenderer: (row, columnfield, value, defaulthtml, columnproperties) => {
              if (defaulthtml.aggregate) {
                return '';
              } else {
                return '<img src="product.png" /><span style="margin: 4px; float: ' + columnproperties.cellsalign + ';">' + value + '</span>'
              }
            }
          },
          {
            text: 'Quantity', dataField: 'orderproductQuantity', width: 100, aggregates: ['sum'],
            aggregatesRenderer: (aggregatesText, column, element, aggregates, type) => { return aggregates.sum; }
          },
          { text: 'Unit Price', dataField: 'orderproductPrice', width: 100, cellsformat: 'c2' },
          {
            text: 'Total Price', dataField: 'orderproductTotalPrice', width: 100, cellsformat: 'c2', aggregates: ['sum'],
            aggregatesRenderer: (aggregatesText, column, element, aggregates, type) => { return this.formatter.format(aggregates.sum); }
          }
        ],
        source: new jqx.dataAdapter({
          id: 'index',
          url: this.baseUrl + 'api/Orders/' + this.companyId.toString() + '/Details',
          dataType: "json",
          dataFields: [
            { name: 'orderId', type: 'number' },
            { name: 'companyId', type: 'number' },
            { name: 'companyName', type: 'string' },
            { name: 'orderDescription', type: 'string' },
            { name: 'orderproductTotalPrice', type: 'number' },
            { name: 'orderproductQuantity', type: 'number' },
            { name: 'orderproductPrice', type: 'number' },
            { name: 'productId', type: 'number' },
            { name: 'productName', type: 'string' }
          ],
          hierarchy: {
            groupingDataFields: [
              { name: 'companyName' },
              { name: 'orderDescription' }
            ],
          }
        }),
        icons(rowKey: number | string, rowData: any): string | boolean {
          switch (rowData.level) {
            case 0: {
              return 'company.png';
            }
            case 1: {
              return 'order.png';
            }
            default: {
              return false;
            }
          }
        },
        ready: () => {
          this.treeGrid.expandAll();
          // Forces refresh so that the aggregate rows display
          this.treeGrid.applyFilters();
        }
      });
  }
}




