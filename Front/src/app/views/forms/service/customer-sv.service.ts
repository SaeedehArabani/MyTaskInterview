import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { customer } from 'src/app/models/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerSvService {

  private apiUrl = 'http://192.168.255.38:8085/customers';  

  constructor(private http: HttpClient) {}
  getCustomers(pageIndex: number=0,pageSize: number = 10): Observable<any>{//Observable<customer[]> {  
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

  deleteCustomer(id: number): Observable<boolean> {  
    return this.http.delete<boolean>(`${this.apiUrl}/${id}`);  
  } 
  downloadFile(){
    return this.http.get(this.apiUrl+'/getTxt',{responseType:'blob',});
  }
  saveFile(blob: Blob, fileName: string) {
    const url = window.URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = fileName;
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
    window.URL.revokeObjectURL(url);
  }
  getCities(): Observable<any>{
    return this.http.get('http://192.168.255.38:8085/cities');
  }
}
