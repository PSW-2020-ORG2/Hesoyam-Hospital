import { TenderListing } from "./tender-listing.model";

export class Tender {
    Id:number;
    TenderListings:TenderListing[];
    EndDate:Date;
    Concluded:Boolean;
    TenderOfferWinnerId:number;
}
