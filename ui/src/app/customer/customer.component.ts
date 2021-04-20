import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
// import { EngineerService } from '../services/engineer.service';
import { CustomerService } from '../services/customer.service';
import { CustomerModel, CustomerType } from '../models/customer.model';




@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss'],

})
export class CustomerComponent implements OnInit {

  public CustomerType: typeof CustomerType = CustomerType;
  public cutomerTypes = Object.keys(this.CustomerType).filter(k => !isNaN(Number(k)));

  public customers: CustomerModel[] = [];

  public newCustomer: CustomerModel = {
    customerId: null,
    name: null,
    type: null
  };

  constructor(
    private customerService: CustomerService) { 
    }

  ngOnInit() {
    this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
  }

  public createCustomer(form: NgForm): void {
    if (form.invalid) {
      alert('form is not valid');
    } else {
      this.customerService.CreateCustomer(this.newCustomer).then(() => {
        this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
      });
    }
  }

}
