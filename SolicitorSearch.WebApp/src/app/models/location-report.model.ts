import { Solicitor } from "./solicitor.model";

export interface LocationReport {
    location: string;
    topSolicitors: Solicitor[];
    averageStarRating: number | null;
}