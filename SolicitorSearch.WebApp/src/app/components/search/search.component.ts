import { Component, inject, signal } from '@angular/core';
import { LocationEnum } from '../../models/location.enum.model';
import { CommonModule } from '@angular/common';
import { Solicitor } from '../../models/solicitor.model';
import { SolicitorService } from '../../services/solicitor.service';
import { FormsModule } from '@angular/forms';
import { SearchResultsComponent } from "../search-results/search-results.component";

@Component({
  selector: 'app-search',
  imports: [CommonModule, FormsModule, SearchResultsComponent],
  templateUrl: './search.component.html',
  styleUrl: './search.component.scss',
})
export class SearchComponent {
  locationOptions = Object.values(LocationEnum);
  private solicitorService = inject(SolicitorService);
  selectedLocation: string = '';
  isSearching = signal(false);  

  solicitors: Solicitor[] = [];

  onSearch(location: string): void {
    if (location != '') {
      this.isSearching.set(true);
      this.solicitorService.searchByLocation(location)
        .subscribe({
          next: (results) => {
          this.solicitors = results;
        },
        error: (err) => {
          console.error('Search failed:', err);
          this.isSearching.set(false);
        },
        complete: () => {
          this.isSearching.set(false);
        }});
    }
  }
}

