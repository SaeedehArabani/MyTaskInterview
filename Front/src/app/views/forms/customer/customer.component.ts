import { NgStyle } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormsModule, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AvatarComponent, ButtonDirective, CardBodyComponent, CardComponent, CardHeaderComponent, ColComponent, FormControlDirective, FormDirective, FormLabelDirective, ProgressBarDirective, ProgressComponent, RowComponent, TableDirective, TextColorDirective } from '@coreui/angular';
import { IconDirective } from '@coreui/icons-angular';
import { customer } from '../../../models/customer';
interface IUser {
  name: string;
  state: string;
  registered: string;
  country: string;
  usage: number;
  period: string;
  payment: string;
  activity: string;
  avatar: string;
  status: string;
  color: string;
}
@Component({
  selector: 'app-customer',
  standalone: true,
  imports: [
    TableDirective,
    AvatarComponent,
    ProgressBarDirective,
    ProgressComponent,
    IconDirective,
    ButtonDirective,
    RowComponent, 
    ColComponent, 
    TextColorDirective, 
    CardComponent, 
    CardHeaderComponent, 
    CardBodyComponent,
     ReactiveFormsModule, 
     FormsModule, 
     FormDirective, 
     FormLabelDirective, 
     FormControlDirective, 
     ButtonDirective, 
     NgStyle
  ],
  templateUrl: './customer.component.html',
  styleUrl: './customer.component.scss'
})
export class CustomerComponent implements OnInit{
  form!: FormGroup;
  curentObj: customer = new customer();
  constructor(private router: Router,
    private fb: FormBuilder
  ) { }
  ngOnInit(): void {

    // let cureents: any = {};
    // Object.keys(this.curentObj).forEach(item => {
    //   cureents[item] = [this.curentObj[item]];
    // });
    // cureents['id'] = [0];
    // cureents['productName'] = [''];
    // cureents['brandId'] = [0];
    // cureents['productCode'] = [''];
    // cureents['productIndex'] = [0];
    // cureents['material'] = [0];
    // cureents['isActive'] = [false];

    // this.form = this.fb.group(cureents);


    // throw new Error('Method not implemented.');
    this.initForm();
    
  }
    initForm() {
      this.form = new FormGroup({
      name: new FormControl('', Validators.required)
    });
      this.form = this.fb.group({
        'name': ['', Validators.required],
        'address': ['', Validators.required],
        'phone': ['', Validators.required],
        'city': ['', Validators.required],
        'fax': ['', Validators.required],
        'coworkers': [0, Validators.required],
      });
    }
    onSubmit(){

      if (this.form.valid) {
      console.log(this.form.value,"formValue");
          
   }
      // console.log(this.form.value,"formValue");
      console.log(this.curentObj,"customerObj");
    }
}
