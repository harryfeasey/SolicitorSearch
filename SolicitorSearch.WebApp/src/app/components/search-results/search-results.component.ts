import { Component, Input } from '@angular/core';
import { Solicitor } from '../../models/solicitor.model';

@Component({
  selector: 'app-search-results',
  imports: [],
  templateUrl: './search-results.component.html',
  styleUrl: './search-results.component.scss',
})
export class SearchResultsComponent {
  @Input() solicitors: Solicitor[] = [];
  @Input() searching: boolean = false;

  ngOnInit() {
    
  }


}
