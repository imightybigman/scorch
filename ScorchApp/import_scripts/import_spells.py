import scrapy
from scrapy.selector import Selector

class roll20Spider(scrapy.Spider):
    name = 'roll20_spider'
    start_urls = ['https://roll20.net/compendium/dnd5e/Spells:Acid%20Arrow#h-Acid%20Arrow']

    def parse(self, response):
        for spellDescription in response.css('.attrListItem'):

            yield {
                'name' : spellDescription.css('.attrName ::text').extract_first()
            }