import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-custom',
  templateUrl: './custom.component.html'
})
export class CustomComponent {

  data: any;

  constructor(private http: HttpClient) { }

  public makeRequest(): void {
    this.data = null;
    const headers = new HttpHeaders();//.append('Authorization', 'Negotiate oRswGaADCgEAoxIEEAEAAAA1K8bRqHPZVQAAAAA=');
    const endpointUrl = "http://localhost:9000/api/values";
    this.http.get(endpointUrl, { headers: headers, withCredentials: true }).subscribe((response: any) => {
      this.data = response;
    });
  }
}
