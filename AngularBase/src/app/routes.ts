import {Routes} from '@angular/router';
import {HomeComponent} from '../app/pages/home/home.component';
import {DetailsComponent} from '../app/pages/details/details.component';

const routeConfig: Routes = [
    {
      path: '',
      component: HomeComponent,
      title: 'Home page',
    },
    {
      path: 'details/:id',
      component: DetailsComponent,
      title: 'Home details',
    },
  ];
  export default routeConfig;