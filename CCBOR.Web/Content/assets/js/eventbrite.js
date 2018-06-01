$(document).ready(function () {

    var token = 'J6EPDFRMRGSIVZELBG7U';
    var orgId = '17349739952'
    var $events = $("#eventBrite");

	$.get('https://www.eventbriteapi.com/v3/events/search/?token=' + token + '&organizer.id=' + orgId + '&expand=venue', function (res) {
		console.log(res);
		if (res.events.length) {

			//display most recent event first
			res.events.sort(function (a, b) {
				return new Date(b.start.local) - new Date(a.start.local);
			});

			for (var i = 0; i <= res.events.length; i++) {
                var event;
                var eventDisp = '';
                var date = '';
                var descr = '';
                var address = '';
                var venue = '';

				event = res.events[i];

                date = displayDate(event.start.local);
                if (event.description.text != null)
                    descr = truncateString(event.description.text, 100);
                if (event.venue.name != null) {
                    venue = event.venue.name + '</br>';
                    if (event.venue.address.localized_multi_line_address_display.length != 0) {
                        address = event.venue.address.localized_multi_line_address_display[0]
                            + '</br>' + event.venue.address.localized_multi_line_address_display[1];
                    }
                }

                eventDisp = '<div class="col-xs-12 col-sm-6 col-md-3"><div class="card"><div class="card-header text-center"><h4>'
                    + event.name.text
                    + '</h4></div><div class="card-body"><p>'
                    + date
                    + '</p>'
                    + '<p>' + venue
                    + address
                    + '</p><p>'
                    + descr
                    + '</p></div><div class="card-footer text-center"><a href="'
                    + event.url
                    + '" class="btn btn-3d btn-lg btn-primary" target="_blank"><i class="glyphicon glyphicon-book"></i>REGISTER</a></div></div></div>'
                $events.after(eventDisp);
            }

        } else {
            $events.after('<div class="col-xs-12 col-sm-6"><h3>Sorry, there are no upcoming events.</h3></div>');
        }
    })
        .fail(function () {
			$events.after('<div class="col-xs-12 col-sm-6"><h3>Sorry, there is a problem displaying the events.  Please visit our <a href="https://www.eventbrite.com/o/columbus-community-bill-of-rights-17349739952" target="_blank">EventBrite page</a> directly to view events.</h3></div>');
        }) ;

    function displayDate(d) {
        
        var monthNames = [
            "January", "February", "March",
            "April", "May", "June", "July",
            "August", "September", "October",
            "November", "December"
        ];
        var date = new Date(d);
        var day = date.getDate();
        var monthIndex = date.getMonth();
        var year = date.getFullYear();
        var hours = date.getHours();
        var minutes = date.getMinutes();
        var ampm = hours >= 12 ? 'pm' : 'am';
        hours = hours % 12;
        hours = hours ? hours : 12; // the hour '0' should be '12'
        minutes = minutes < 10 ? '0' + minutes : minutes;

        return monthNames[monthIndex] + ' ' + day + ', ' + year + ' at ' + hours + ':' + minutes + ' ' + ampm;
        
    }

    function truncateString(s, l) {
        if (s.length >= l)
            return s.substring(0, l) + '...'
        else return s;
    }

});


