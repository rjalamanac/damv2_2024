import { Injectable } from '@angular/core';
import { HousingLocation } from '../models/housinglocation';

@Injectable({
  providedIn: 'root'
})
export class HousingService {
  housingLocationList: HousingLocation[];
  readonly baseUrl = 'http://localhost:5072/api/House';
  readonly authUrl = 'http://localhost:5072/api/users/login';
  private token: string | null = null;

  constructor() {
    this.housingLocationList = [];
  }

  async login(username: string, password: string): Promise<boolean> {
    const response = await fetch(this.authUrl, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ UserName: username, Password: password })
    });

    if (!response.ok) {
      console.error('Login failed');
      return false;
    }

    const responseData = await response.json();
    this.token = responseData?.result?.token ?? null;
    return this.token !== null;
  }

  async getAllHousingLocations(): Promise<HousingLocation[]> {
    if (!this.token) {
      console.error('User is not authenticated');
      await this.login("Bimba_Joga", "u76x&s~:vtDVX*[4%#")
    }

    const response = await fetch(this.baseUrl, {
      method: 'GET',
      headers: { 'Authorization': `Bearer ${this.token}` }
    });

    return (await response.json()) ?? [];
  }

  async getHousingLocationById(id: number): Promise<HousingLocation | undefined> {
    if (!this.token) {
      console.error('User is not authenticated');
      return undefined;
    }

    const response = await fetch(`${this.baseUrl}/${id}`, {
      method: 'GET',
      headers: { 'Authorization': `Bearer ${this.token}` }
    });

    return (await response.json()) ?? undefined;
  }

  submitApplication(firstName: string, lastName: string, email: string) {
    console.log(
      `Homes application received: firstName: ${firstName}, lastName: ${lastName}, email: ${email}.`
    );
  }
}