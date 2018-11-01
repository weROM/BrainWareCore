import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { OrdersComponent } from './brainware-orders/brainware-orders.component'
import { jqxTreeGridComponent } from '../../node_modules/jqwidgets-framework/jqwidgets-ts/angular_jqxtreegrid';

@NgModule({
  declarations: [
    AppComponent,
    OrdersComponent,
    jqxTreeGridComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
