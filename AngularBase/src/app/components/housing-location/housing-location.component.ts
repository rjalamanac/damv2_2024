import { Component, Input } from '@angular/core';
import { HousingLocation } from '../../models/housinglocation';

@Component({
  selector: 'app-housing-location',
  imports: [],
  templateUrl: './housing-location.component.html',
  styleUrls: ['./housing-location.component.css']
})
export class HousingLocationComponent {
  
  @Input() housingLocation!: HousingLocation;
  
}
