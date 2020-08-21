import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-custom',
  templateUrl: './custom.component.html'
})
export class CustomComponent {

  data: any;

  constructor(private http: HttpClient) { }

  public makeRequest(): void {
    this.data = null;
    const endpointUrl = "http://localhost:9000/api/values";
    this.http.get(endpointUrl).subscribe((response: any) => {
      this.data = response;
    });
  }
}
