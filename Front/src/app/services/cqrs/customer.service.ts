import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
// import { customer } from 'app/models/customer';
import { Observable } from 'rxjs';
import { customer } from 'src/app/models/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  private apiUrl = 'http://192.168.255.38:8085/customers';//'http://localhost:8085/customers';  

  constructor(private http: HttpClient,@Inject(String) private apiName: String) {
     {
      
    }
  } 
  
  getCustomers(pageIndex: number=0,pageSize: number = 10): Observable<customer[]> {  
    return this.http.get<customer[]>(this.apiUrl+`?pageIndex=${pageIndex}&pageSize=${pageSize}`);  
  }  

  getCustomerById(id: number): Observable<customer> {  
    return this.http.get<customer>(`${this.apiUrl}/${id}`);  
  }  
  createCustomer(customer: customer): Observable<customer> {  
    return this.http.post<customer>(this.apiUrl, customer);  
  }  

  updateCustomer(id: number, customer: customer): Observable<customer> {  
    return this.http.put<customer>(`${this.apiUrl}/${id}`, customer);  
  }  

  deleteCustomer(id: number): Observable<void> {  
    return this.http.delete<void>(`${this.apiUrl}/${id}`);  
  } 
}
