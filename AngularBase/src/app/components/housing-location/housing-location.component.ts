import { Component, Input } from '@angular/core';
import { HousingLocation } from '../../models/housinglocation';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-housing-location',
  imports: [RouterModule],
  templateUrl: './housing-location.component.html',
  styleUrls: ['./housing-location.component.css']
})
export class HousingLocationComponent {

  @Input() housingLocation!: HousingLocation;

}
