_01 Adding a new entity to the context
_02 Updating an entity in the context
_03 Delete an entity in the context
_04 Delete a group of entities from the context
_05 Adding a new entity to the context and catching the validation errors

//********************************************  
// _01 Adding a new entity to the context
//********************************************
using (var context = new BloggingContext())
{
    var blog = new Blog { Name = "ADO.NET Blog" };
    context.Blogs.Add(blog);
    context.SaveChanges();
}
or
using (var context = new BloggingContext())
{
    var blog = new Blog { Name = "ADO.NET Blog" };
    context.Entry(blog).State = EntityState.Added;
    context.SaveChanges();
}

//********************************************  
// _02 Updating an entity in the context
//********************************************
var existingBlog = new Blog { BlogId = 1, Name = "ADO.NET Blog" };
 
using (var context = new BloggingContext())
{
    context.Entry(existingBlog).State = EntityState.Modified;
     // Do some more work... 
     context.SaveChanges();
}
// or
using (var db = new CountyMileageEntities())
{
	var trip = db.trips.Find(vehicleTrip.trip_id);
	db.Entry(trip).CurrentValues.SetValues(vehicleTrip);
	int count = db.SaveChanges();
}

//********************************************   
// _03 Delete an entity in the context
//********************************************
using (var db = new CountyMileageEntities())
{
	trip tripToDelete = db.trips.Find(trip_id);
	if (tripToDelete != null)
	{
		db.trips.Remove(tripToDelete);
		count = db.SaveChanges();
	}
	else
		return ResultType.NotFound;
}
//********************************************   
// _04 Delete a group of entities from the context
//********************************************
db.trips.RemoveRange(db.trips.Where(t = > t.claim_id == claimID));
db.SaveChanges();

//********************************************   
// _05 Adding a new entity to the context and catching the validation errors
//********************************************
try
{
	using (var db = new CountyMileageEntities())
	{
		var result = db.claims.Add(mileageClaim);
		db.SaveChanges();
	}
}
catch (DbEntityValidationException e)
{
	foreach(var eve in e.EntityValidationErrors)
	{
		var info = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
			eve.Entry.Entity.GetType().Name, eve.Entry.State);
		foreach(var ve in eve.ValidationErrors)
		{
			var info2 = string.Format("- Property: \"{0}\", Error: \"{1}\"",
				ve.PropertyName, ve.ErrorMessage);
		}
	}
	throw;
}