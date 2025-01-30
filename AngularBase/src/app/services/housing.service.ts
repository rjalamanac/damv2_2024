import { Injectable } from '@angular/core';
import { HousingLocation } from '../models/housinglocation';

@Injectable({
  providedIn: 'root'
})
export class HousingService {
  housingLocationList: HousingLocation[];
  readonly baseUrl = 'http://localhost:5072/api/House';
  constructor() {
    this.housingLocationList= [];

   }

   async getAllHousingLocations(): Promise<HousingLocation[]> {
    let headers = new Headers();
    headers.append('Authorization', 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJpbWJhX0pvZ2EiLCJyb2xlIjoiYWRtaW4iLCJuYmYiOjE3MzgyNjQ3MTYsImV4cCI6MTczODI2NTEzNiwiaWF0IjoxNzM4MjY0NzE2fQ.0aj1ScoIed0ULksXfUel8MxbVWDlYTiUQGgYl2FHPkI');
    const data = await fetch(this.baseUrl,{method:'GET',
      headers: headers,
     });
    return (await data.json()) ?? [];
  }

  async getHousingLocationById(id: number): Promise<HousingLocation | undefined> {
    const data = await fetch(`${this.baseUrl}/${id}`);
    return (await data.json()) ?? {};
  }

  submitApplication(firstName: string, lastName: string, email: string) {
    console.log(
      `Homes application received: firstName: ${firstName}, lastName: ${lastName}, email: ${email}.`,
    );
  }
}
