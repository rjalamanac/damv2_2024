import {Routes} from '@angular/router';
import {HomeComponent} from '../app/pages/home/home.component';
import {DetailsComponent} from '../app/pages/details/details.component';
import { PageNotFoundComponent } from './pages/page-not-found/page-not-found.component';

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
    {
      path: '**',
      component: PageNotFoundComponent,
    },
  ];
  export default routeConfig;