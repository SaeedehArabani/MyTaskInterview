import { NgStyle } from '@angular/common';
import { Component, viewChild } from '@angular/core';
import {
  ReactiveFormsModule,
  FormsModule,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import {
  AvatarComponent,
  ButtonDirective,
  CardBodyComponent,
  CardComponent,
  CardHeaderComponent,
  ColComponent,
  FormControlDirective,
  FormDirective,
  FormLabelDirective,
  ProgressBarDirective,
  ProgressComponent,
  RowComponent,
  TableDirective,
  TextColorDirective,
} from '@coreui/angular';
import { IconDirective } from '@coreui/icons-angular';
import { Observable } from 'rxjs';
import { CustomerSvService } from '../service/customer-sv.service';
import { customer } from 'src/app/models/customer';
import { city } from 'src/app/models/city';
import { result } from 'lodash-es';
import { saveAs } from 'file-saver';

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
  selector: 'app-search',
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
    NgStyle,
  ],
  templateUrl: './search.component.html',
  styleUrl: './search.component.scss',
})
export class SearchComponent {
  curentObj: customer = new customer();
  cities: Array<city> = [];
  showEditBtn: boolean = false;
  editCuId: number = 0;
  selectedCityId: number = 0;
  searchTxt: string = '';
  form!: FormGroup;
  constructor(
    private router: Router,
    public customerService: CustomerSvService,
    private fb: FormBuilder
  ) {}
  filterdList: Array<customer> = [];
  customers: Array<customer> = [
    {
      id: 1,
      name: 'Reza',
      address: 'Tehran-ostadmoeen',
      city: 1,
      phone: '021-47300',
      fax: '021-47400',
      coworkers: 10,
      // avatar: './assets/images/avatars/1.jpg',
    },
    {
      id: 2,
      name: 'Ahmad',
      address: 'Tehran-ostadmoeen',
      city: 2,
      phone: '021-47300',
      fax: '021-47400',
      coworkers: 10,
      // avatar: './assets/images/avatars/1.jpg',
    },
    {
      id: 3,
      name: 'Ali',
      address: 'Tehran-ostadmoeen',
      city: 3,
      phone: '021-47300',
      fax: '021-47400',
      coworkers: 10,
      // avatar: './assets/images/avatars/1.jpg',
    },
    {
      id: 4,
      name: 'Rahman',
      address: 'Tehran-ostadmoeen',
      city: 1,
      phone: '021-47300',
      fax: '021-47400',
      coworkers: 10,
      // avatar: './assets/images/avatars/1.jpg',
    },
  ];
  back() {
    debugger;
    console.log('back btn clicked');
    this.router.navigate(['dashboard']);
    //return;
  }
  search() {
    this.customerService.getCustomers(0, 10).subscribe((result) => {});
  }
  delete(indx: any) {
    this.customerService
      .deleteCustomer(this.customers[indx].id)
      .subscribe((result) => {
        if (result) this.getAllCustomers();
      });
  }
  getCustomerById(id: number) {
    this.customerService.getCustomerById(id).subscribe((result) => {
      debugger;
      console.log(result);
    });
  }

  download() {
    this.customerService.downloadFile().subscribe((blob) => {
      this.customerService.saveFile(blob, 'customersList.txt');
    });
  }

  ngOnInit(): void {
    this.initForm();
    this.getCities();
    this.getAllCustomers();
  }
  initForm() {
    this.form = new FormGroup({
      name: new FormControl('', Validators.required),
    });
    this.form = this.fb.group({
      name: ['', Validators.required],
      address: ['', Validators.required],
      phone: ['', Validators.required],
      city: ['', Validators.required],
      fax: ['', Validators.required],
      coworkers: [0, Validators.required],
    });
  }
  save() {
    this.customerService.createCustomer(this.curentObj).subscribe((result) => {
      console.log(result);
      this.getAllCustomers();
      this.curentObj = new customer();
    });
  }
  edit(id: number) {
    debugger;
    console.log(this.customers[id]);
    this.curentObj = this.customers[id];
    this.showEditBtn = true;
    this.editCuId = id;
    let cityname = this.customers[id].city;
    this.curentObj.city = this.cities.find(
      (x) => x.title == cityname?.toString()
    )?.id;
  }
  update() {
    this.customerService
      .updateCustomer(this.editCuId, this.curentObj)
      .subscribe((result) => {
        console.log(result);
        debugger;
        this.curentObj = new customer();
        this.getAllCustomers();
      });
    this.showEditBtn = false;
    this.editCuId = 0;
  }
  cancel() {
    this.showEditBtn = false;
    this.editCuId = 0;
    this.curentObj = new customer();
  }
  getCities() {
    this.customerService.getCities().subscribe((result) => {
      this.cities = result.cities;
    });
  }
  getAllCustomers() {
    this.customerService.getCustomers().subscribe((result) => {
      this.customers = result.customers.data;
      this.filterdList = result.customers.data;
    });
  }
  onChangeCity(evt: any) {
    this.curentObj.city = parseInt(evt.value);
  }
  onSearchName(evt: any) {
    this.customers = this.filterdList;
    this.customers = this.customers.filter((item) =>
      item.name.toUpperCase().includes(evt.target.value.toUpperCase())
    );
  }
}
