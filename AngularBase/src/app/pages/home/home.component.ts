import { Component,inject} from '@angular/core';
import {HousingLocationComponent} from '../../components/housing-location/housing-location.component';
import {HousingLocation} from '../../models/housinglocation'
import { CommonModule } from '@angular/common';
import {HousingService} from '../../services/housing.service';

@Component({
  selector: 'app-home',
  imports: [CommonModule, HousingLocationComponent],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  housingLocationList: HousingLocation[];

  constructor(private housingService: HousingService) {
    this.housingLocationList = this.housingService.getAllHousingLocations();
  }

  
}
