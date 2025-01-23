import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HousingLocation } from 'src/app/models/housinglocation';
import { HousingService } from 'src/app/services/housing.service';

@Component({
  selector: 'app-details',
  imports: [],
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent {
  route: ActivatedRoute = inject(ActivatedRoute);
  housingLocation: HousingLocation | undefined;
  constructor(housingService: HousingService) {
      const housingLocationId = Number(this.route.snapshot.params['id']);
      this.housingLocation = housingService.getHousingLocationById(housingLocationId);
  }
}
