import {Component} from '@angular/core';
import {HomeComponent} from './pages/home/home.component';
import {RouterModule} from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterModule],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'Pagina Primera Sufrida';
}
