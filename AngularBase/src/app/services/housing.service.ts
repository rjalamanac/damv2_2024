import { Injectable } from '@angular/core';
import { HousingLocation } from '../models/housinglocation';

@Injectable({
  providedIn: 'root'
})
export class HousingService {
  housingLocationList: HousingLocation[];
  readonly baseUrl = 'https://localhost:7777/api/House';
  constructor() {
    this.housingLocationList= [];
   }

   async getAllHousingLocations(): Promise<HousingLocation[]> {
    const data = await fetch(this.baseUrl);
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
